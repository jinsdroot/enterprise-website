using System;
using System.Text;

namespace Cnkj.UserControl
{
	internal class JavaScriptBuilder
	{
		private StringBuilder sb = new StringBuilder();
		private int currIndent = 0;
		private int openBlocks = 0;
		private bool format = true;

		/// <summary>
		/// Instantiate a JavaScriptWriter for unformatted code
		/// </summary>
		internal JavaScriptBuilder()
		{
		}

		/// <summary>
		/// Instantiate a JavaScriptWriter with Formatted switch
		/// </summary>
		/// <param name="Formatted">Format Code?</param>
		internal JavaScriptBuilder(bool Formatted)
		{
			format = Formatted;
		}

		/// <summary>
		/// Current level of indent
		/// </summary>
		internal int Indent
		{
			get { return currIndent; }
			set { currIndent = value; }
		}

		/// <summary>
		/// Add a line of code
		/// </summary>
		/// <param name="parts">Parts of the line as array of strings</param>
		internal void AddLine(params string[] parts)
		{
			// Open line with tabs, where formatting is set
			if (format)
				for (int i = 0; i < currIndent; i++)
					sb.Append("\t");

			// Append parts of the line to StringBuilder individually
			// - much more efficient than sb.AppendFormat
			foreach (string part in parts)
				sb.Append(part);

			// Append a new line where formatting is set or a space
			// where it isn't
			if (format)
				sb.Append(Environment.NewLine);
			else
				if (parts.Length > 0)
					sb.Append(" ");
		}

		/// <summary>
		/// Open a code block and increase indent level
		/// </summary>
		internal void OpenBlock()
		{
			AddLine("{");
			currIndent++;
			openBlocks++;
		}

		/// <summary>
		/// Close code block and decrease indent level
		/// </summary>
		internal void CloseBlock()
		{
			// Check that there is at least one block open
			if (openBlocks < 1)
				throw new InvalidOperationException("JavaScriptBuilder.CloseBlock() called when no blocks open");

			currIndent--;
			openBlocks--;
			AddLine("}");
		}

		/// <summary>
		/// Add a comment line to the code, where formatting is set
		/// </summary>
		/// <param name="CommentText">Parts of the comment as an array of strings</param>
		internal void AddCommentLine(params string[] CommentText)
		{
			if (format)
			{
				// Open the line with tab indent
				for (int i = 0; i < currIndent; i++)
					sb.Append("\t");

				// ... and a comment marker
				sb.Append("// ");

				// Append all the parts of the line
				foreach (string part in CommentText)
					sb.Append(part);

				// Throw in a new line
				sb.Append(Environment.NewLine);
			}
		}

		/// <summary>
		/// Convert to string (adding script start and end tags)
		/// </summary>
		/// <returns>Inner script text</returns>
		public override string ToString()
		{
			// Check that each indent has a matching outdent
			// - if not then there's almost certainly a problem in the javascript
			if (openBlocks > 0)
				throw new InvalidOperationException("JavaScriptBuilder: code blocks are still open");

			// Add the <script> tags and some comment blocks, so that
			// browsers that don't support scripts will not crash horribly
			return String.Format(
				"{0}<script language=\"javascript\">{0}<!--{0}{1}// -->{0}</script>{0}",
				Environment.NewLine,
				sb
			);
		}
	}
}
