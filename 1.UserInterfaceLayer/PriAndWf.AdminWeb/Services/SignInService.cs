using PriAndWf.AdminWeb.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriAndWf.AdminWeb.Services
{
    public interface ISignInService : IDisposable
    {
        int SignIn(SignInSModel model);
        List<int> GetCanSignList();
    }
    public class SignInService : ISignInService
    {
        private List<int> allList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        private List<int> canSignList = new List<int>() { 1, 7, 8 };

        public void Dispose() { }

        public int SignIn(SignInSModel model)
        {
            return 0;
        }
        public List<int> GetCanSignList()
        {
            return allList.Where(m => new List<int> { 1, 7, 8 }.Contains(m)).ToList();
        }
    }
}