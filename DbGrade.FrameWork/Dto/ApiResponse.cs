using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class ApiResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Msg { get; set; }

        public static ApiResponse BadRequest(string msg = null)
        {
            return new ApiResponse()
            {
                Code = HttpStatusCode.BadRequest,
                Msg = msg
            };
        }

        public static ApiResponse OK(string msg = null)
        {
            return new ApiResponse()
            {
                Code = HttpStatusCode.OK,
                Msg = msg
            };
        }

        public static ApiResponse OK<T>(T data, string msg= null)
        {
            return new ApiResponse<T>()
            {
                Code = HttpStatusCode.OK,
                Msg = msg,
                Data = data
            };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {

        public T Data { get; set; }
    }


}
