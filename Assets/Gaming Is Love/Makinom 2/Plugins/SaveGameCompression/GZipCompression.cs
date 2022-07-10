
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;

namespace GamingIsLove.Makinom.Plugins
{
	public class GZipCompression : ICompressionHandler
	{
		public GZipCompression()
		{

		}

		public string CompressString(string text)
		{
			MemoryStream memoryStrea = null;
			GZipOutputStream gzipStream = null;
			string result;
			try
			{
				memoryStrea = new MemoryStream();
				System.Int32 size = text.Length;

				using(BinaryWriter writer = new BinaryWriter(memoryStrea, Encoding.UTF8))
				{
					writer.Write(size);

					gzipStream = new GZipOutputStream(memoryStrea);
					gzipStream.Write(Encoding.UTF8.GetBytes(text), 0, text.Length);

					gzipStream.Close();
					result = System.Convert.ToBase64String(memoryStrea.ToArray());
					memoryStrea.Close();

					writer.Close();
				}
			}
			catch(System.Exception)
			{
				result = text;
			}
			finally
			{
				if(gzipStream != null)
				{
					gzipStream.Dispose();
				}
				if(memoryStrea != null)
				{
					memoryStrea.Dispose();
				}
			}
			return result;
		}

		public string DecompressString(string text)
		{
			string result;
			MemoryStream memoryStream = null;
			GZipInputStream gzipStream = null;
			try
			{
				memoryStream = new MemoryStream(System.Convert.FromBase64String(text));

				using(BinaryReader reader = new BinaryReader(memoryStream, Encoding.UTF8))
				{
					System.Int32 size = reader.ReadInt32();

					gzipStream = new GZipInputStream(memoryStream);
					byte[] bytesUncompressed = new byte[size];
					gzipStream.Read(bytesUncompressed, 0, bytesUncompressed.Length);
					gzipStream.Close();
					memoryStream.Close();

					result = Encoding.UTF8.GetString(bytesUncompressed);

					reader.Close();
				}
			}
			catch(System.Exception)
			{
				result = text;
			}
			finally
			{
				if(gzipStream != null)
				{
					gzipStream.Dispose();
				}
				if(memoryStream != null)
				{
					memoryStream.Dispose();
				}
			}
			return result;
		}
	}
}
