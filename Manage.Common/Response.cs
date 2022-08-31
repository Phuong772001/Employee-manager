using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public static class Response
    {
        public static BaseResponse SuccessResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = true,
                message = "success",
                status = "200"
            };
            return response;
        }
        public static BaseResponse SuccessResponse(object item)
        {
            BaseResponse response = new BaseResponse
            {
                success = true,
                message = "success",
                status = "200",
                item = item
            };
            return response;
        }
        public static BaseResponse DuplicateDataResponse(string message)
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "400",
                message = message
            };
            return response;
        }
        public static BaseResponse TokenInvalidResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "401",
                message = "invalid token"
            };
            return response;
        }
        public static BaseResponse TokenExpirationResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "402",
                message = "token expiration"
            };
            return response;
        }
        public static BaseResponse ForbiddenResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                message = "forbidden",
                status = "403"
            };
            return response;
        }
        public static BaseResponse NotFoundResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "404",
                message = "Not found"
            };
            return response;
        }
        public static BaseResponse NotFoundResponse(string mesage)
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "404",
                message = mesage
            };
            return response;
        }
        public static BaseResponse BadLoginResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "405",
                message = "wrong username or password"
            };
            return response;
        }
        public static BaseResponse DataNullResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "406",
                message = "please fill all empty box"
            };
            return response;
        }
        public static BaseResponse InvalidPasswordResponse(string message)
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "407",
                message = message
            };
            return response;
        }
        public static BaseResponse AuthHeaderResponse()
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "408",
                message = "user was not login"
            };
            return response;
        }
        public static BaseResponse ExceptionResponse(Exception ex)
        {
            BaseResponse response = new BaseResponse
            {
                success = false,
                status = "500",
                message = "server error",
                item = ex.Message,
            };
            return response;
        }
    }
}
