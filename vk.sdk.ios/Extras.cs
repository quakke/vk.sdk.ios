using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Foundation;
using VKontakte.Core;
using VKontakte.API.Models;

namespace VKontakte
{
	partial class VKPermissions
	{
		// extern NSArray * VKParseVkPermissionsFromInteger (NSInteger permissionsValue);
		[DllImport("__Internal", EntryPoint = "VKParseVkPermissionsFromInteger")]
		static extern string[] ParsePermissions(nint permissionsValue);
	}

	public class VKException : Exception
	{
        public VKException(NSError error)
            : this(new VKError())
        {
            NSError = error;
        }

        public VKException(VKError error)
			: base(error.ErrorMessage)
		{
			Error = error;
		}

		public VKException(string message, VKError error)
			: base(message)
		{
			Error = error;
		}

		public VKException(VKError error, Exception innerException)
			: base(error.ErrorMessage, innerException)
		{
			Error = error;
		}

		public VKException(string message, VKError error, Exception innerException)
			: base(message, innerException)
		{
			Error = error;
		}

		public VKError Error { get; private set; }

		public NSError NSError { get; private set; }
	}
}

namespace VKontakte.Core
{
	partial class VKError
	{
        //public NSError ToNSError()
        //{
        //    return INSError_VKError.FromVKError(this);
        //}
    }

	partial class VKRequest
	{
		public Task<IVKResponse> ExecuteAsync()
		{
			var tcs = new TaskCompletionSource<IVKResponse>();
            
            Execute(response => tcs.SetResult(response),
                error => tcs.SetException(new Exception(error.Message)));

            return tcs.Task;
		}

		public static VKRequest Create(string method, NSDictionary parameters, ObjCRuntime.Class modelClass)
		{
			return Create(method, parameters, modelClass);
		}

		public static VKRequest Create<T>(string method, NSDictionary parameters)
			where T : IVKApiObject
		{
			return Create(method, parameters, new ObjCRuntime.Class(typeof(T)));
		}
	}
}