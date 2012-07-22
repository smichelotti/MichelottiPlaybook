using System;
namespace MichelottiPlaybook.Services
{
    public interface IPlaybookEmailer
    {
        void SendApprovalRequestEmail(string name);
    }
}
