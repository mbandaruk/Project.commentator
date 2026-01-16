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
		tbList.Text = string.Empty;

		var root = tbRoot.Text;
		ProcessDir(root, DoNothing);
	}


	private void button2_Click(object sender, EventArgs e)
	{
		tbList.Text = string.Empty;

		var root = tbRoot.Text;
		ProcessDir(root, CommentFile);
	}



	private void ProcessDir(string path, Action<FileInfo> action)
	{
		// TODO check if not exists

		var di = new DirectoryInfo(path);

		tbList.Text += path + Environment.NewLine; // TODO delegate

		foreach (var fi in di.GetFiles())
		{
			tbList.Text += fi.Name + Environment.NewLine; // TODO delegate
			action(fi);
		}

		foreach (var fi in di.GetDirectories())
		{
			ProcessDir(fi.FullName, action);
		}
	}





	private void DoNothing(FileInfo fileInfo)
	{
	}


	/// <summary>
	/// Comment all lines
	/// </summary>
	private void CommentFile(FileInfo fileInfo)
	{
		// TODO check if not exists

		tbList.Text += "comment" + Environment.NewLine; // TODO delegate

		// copy content to a new file and comment all lines
		var basicName = fileInfo.FullName;
		var newName = basicName + ".new";

		var comment = fileInfo.Extension switch
		{
			".cs" => "//",
			".vb" => "'",
			_ => throw new NotImplementedException()
		};

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
