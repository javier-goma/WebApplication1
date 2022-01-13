using System.Net.Mail;
using WebApplication1.Models;

namespace WebApplication1.HTTPModels
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}