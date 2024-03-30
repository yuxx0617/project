using Microsoft.AspNetCore.Mvc;
using TEST.Services.MemberDBService;

namespace TEST.Contronllers.MemberContronller
{
    public class MemberContronller : ControllerBase
    {
        private readonly MemberDBService memberDBService = new MemberDBService();
        
    }
}