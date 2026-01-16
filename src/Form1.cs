using Utils.IO;

namespace Commentator;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();


		var root = PathHelper.EnsurePath(createDirectoriesIfAbsent: true, "Project.commentator.tmp", "test1");
		tbRoot.Text = root;

	}

	private void button1_Click(object sender, EventArgs e)
	{
		tbList.Text = string.Empty; // TODO delegate

		var root = tbRoot.Text;
		ProcessDir(root, DoNothing);
	}


	private void button2_Click(object sender, EventArgs e)
	{
		tbList.Text = string.Empty; // TODO delegate

		var root = tbRoot.Text;
		ProcessDir(root, CommentFile);
	}


	private string[] exludeDirs = new[] { "bin", "obj" };
	private string[] includeFiles = new[] { ".cs", ".vb" };


	private void ProcessDir(string path, Action<FileInfo> action)
	{
		var di = new DirectoryInfo(path);
		ProcessDir(di, action);
	}

	private void ProcessDir(DirectoryInfo dirInfo, Action<FileInfo> action)
	{
		// TODO check if not exists


		if (exludeDirs.Contains(dirInfo.Name))
		{
			//tbList.Text += dirInfo.FullName + " skip" + Environment.NewLine; //debug
		}
		else
		{
			tbList.Text += dirInfo.FullName + Environment.NewLine; // TODO delegate

			foreach (var fi in dirInfo.GetFiles())
				ProcessFile(fi, action);

			foreach (var di in dirInfo.GetDirectories())
				ProcessDir(di, action);
		}
	}


	private void ProcessFile(FileInfo fileInfo, Action<FileInfo> action)
	{
		// TODO check if not exists

		if (includeFiles.Contains(fileInfo.Extension))
		{
			tbList.Text += "  " + fileInfo.Name + Environment.NewLine; // TODO delegate
			action(fileInfo);
		}
		else
		{
			//tbList.Text += "  " + fileInfo.Name + " skip" + Environment.NewLine; //debug
		}
	}




	private void DoNothing(FileInfo fileInfo)
	{
		//tbList.Text += "    -" + Environment.NewLine; // debug
	}


	/// <summary>
	/// Comment all lines
	/// </summary>
	private void CommentFile(FileInfo fileInfo)
	{
		//tbList.Text += "    comment" + Environment.NewLine; // debug

		var comment = string.Empty;
		switch (fileInfo.Extension)
		{
			case ".cs":
				comment = "//";
				break;
			case ".vb":
				comment = "'";
				break;
			default:
				throw new InvalidOperationException();
		};

		// copy content to a new file and comment all lines
		var basicName = fileInfo.FullName;
		var newName = basicName + ".new";


		using (var reader = new StreamReader(basicName))
		using (var fStream = new FileStream(newName, FileMode.Create))
		using (var writer = new StreamWriter(fStream))
		{
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				writer.WriteLine(comment + line);
			}
		}

		// swap old and new files, remove old version
		var oldName = basicName + ".old";
		File.Move(basicName, oldName);
		File.Move(newName, basicName);
		File.Delete(oldName);
	}

}
