using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Behavioral.TemplateMethod.DisposePattern
{
	public class ComplexResourceHolder : IDisposable
	{
		//unmanaged resource
		private IntPtr _buffer;

		//managed resource
		private SafeHandle _handle;

		public ComplexResourceHolder()
		{
			_buffer = AllocateBuffer();
			_handle = new SafeWaitHandle(IntPtr.Zero, true);
		}

		protected virtual void Dispose(bool disposing)
		{
			//release unmanaged resources in any case
			ReleaseBuffer(_buffer);

			//method called from Dispose(), release managed resources
			if (disposing)
			{
				if (_handle != null)
				{
					_handle.Dispose();
				}
			}
		}

		//called during garbage collection at unknown time (order for managed resources is unkonwn)
		//when this is called, there is no guarantee that managed resources were not 'finalized' by their own finalizers
		//so we need only to dispose unmanaged resources
		~ComplexResourceHolder()
		{
			Dispose(false);
		}

		//this is called by user code
		//after this call reference to 'dead' object still exists
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void ReleaseBuffer(IntPtr buffer)
		{
			throw new NotImplementedException();
		}

		private IntPtr AllocateBuffer()
		{
			throw new NotImplementedException();
		}
	}

	public class ProperComplexResourceHolder
	{
		//unmanaged resource
		private IntPtr _buffer;

		//managed resource
		private SafeHandle _handle;

		public ProperComplexResourceHolder()
		{
			_buffer = AllocateBuffer();
			_handle = new SafeWaitHandle(IntPtr.Zero, true);
		}

		~ProperComplexResourceHolder()
		{
			DisposeNativeResources();
		}

		public void Dispose()
		{
			DisposeNativeResources();
			DisposeManagedResources();
			GC.SuppressFinalize(this);
		}

		protected virtual void DisposeNativeResources()
		{
			ReleaseBuffer(_buffer);
		}

		protected virtual void DisposeManagedResources()
		{
			if (_handle != null)
				_handle.Dispose();
		}

		private void ReleaseBuffer(IntPtr buffer)
		{
			throw new NotImplementedException();
		}

		private IntPtr AllocateBuffer()
		{
			throw new NotImplementedException();
		}
	}
}