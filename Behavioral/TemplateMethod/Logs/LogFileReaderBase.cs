using System;
using System.Collections.Generic;
using System.IO;

namespace Behavioral.TemplateMethod.Logs
{
	//we can use template method once again for one algorith step from base (LogReader) class
	public abstract class LogFileReaderBase : LogReader, IDisposable
	{
		private readonly Lazy<Stream> _stream;

		protected LogFileReaderBase(string fileName)
		{
			_stream = new Lazy<Stream>(() => new FileStream(fileName, FileMode.Open));
		}

		protected override IEnumerable<string> ReadEntries(ref int position)
		{
			if (_stream.Value.Position != position)
				_stream.Value.Seek(position, SeekOrigin.Begin);

			return ReadLineByLine(_stream.Value, ref position);
		}

		protected abstract override LogEntry ParseLogEntry(string stringEntry);

		private IEnumerable<string> ReadLineByLine(Stream stream, ref int position)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			if (_stream.IsValueCreated)
			{
				_stream.Value.Close();
			}
		}
	}

	//sometimes it's a good idea to extract a strategy for one step of algorithm
	public interface ILogParser
	{
		LogEntry ParseLogEntry(string stringEntry);
	}

	//this is questionable, as for me
	public abstract class LogFileReaderBase1 : LogReader, IDisposable
	{
		private readonly Lazy<Stream> _stream;
		private readonly ILogParser _logParser;

		protected LogFileReaderBase1(string fileName, ILogParser logParser)
		{
			_logParser = logParser;
			_stream = new Lazy<Stream>(() => new FileStream(fileName, FileMode.Open));
		}

		protected override IEnumerable<string> ReadEntries(ref int position)
		{
			if (_stream.Value.Position != position)
				_stream.Value.Seek(position, SeekOrigin.Begin);

			return ReadLineByLine(_stream.Value, ref position);
		}

		protected override LogEntry ParseLogEntry(string stringEntry)
		{
			return _logParser.ParseLogEntry(stringEntry);
		}

		private IEnumerable<string> ReadLineByLine(Stream stream, ref int position)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			if (_stream.IsValueCreated)
			{
				_stream.Value.Close();
			}
		}
	}

	//how to test (extract and override)
	public abstract class LogFileReaderBaseForTests : LogReader, IDisposable
	{
		private readonly Lazy<Stream> _stream;

		protected LogFileReaderBaseForTests(string fileName)
		{
			_stream = new Lazy<Stream>(() => OpenFileStream(fileName));
		}

		//extract opening stream to virtual method
		protected virtual Stream OpenFileStream(string fileName)
		{
			return new FileStream(fileName, FileMode.Open);
		}

		protected override IEnumerable<string> ReadEntries(ref int position)
		{
			if (_stream.Value.Position != position)
				_stream.Value.Seek(position, SeekOrigin.Begin);

			return ReadLineByLine(_stream.Value, ref position);
		}

		protected abstract override LogEntry ParseLogEntry(string stringEntry);

		private IEnumerable<string> ReadLineByLine(Stream stream, ref int position)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			if (_stream.IsValueCreated)
			{
				_stream.Value.Close();
			}
		}
	}

	//and create fake one
	public class FakeLogFileReader : LogFileReaderBaseForTests
	{
		private readonly MemoryStream _mockStream;

		public FakeLogFileReader(MemoryStream mockStream) : base(string.Empty)
		{
			_mockStream = mockStream;
		}

		protected override Stream OpenFileStream(string fileName)
		{
			return _mockStream;
		}

		protected override LogEntry ParseLogEntry(string stringEntry)
		{
			throw new NotImplementedException();
		}
	}
}