using EskaPolicies;

namespace Service.Interfaces
{
    public interface IWSCoreService
    {
        (bool, string?) PushToPolicyWrapperCore(int? Id, string? connection, string? FinanceConnection, bool deletependingEnd, string ESKAServiceURL, string ESKAServiceEndoURL, string? EskaIGeneralConnection);


        bool PushYakeen();
        PostPolicyResponse PushPolicyToPost(long Id, string CreatedBy, string policySegment, string ESKAServiceURL);

    }
}
