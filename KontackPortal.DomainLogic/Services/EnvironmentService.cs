using System.Diagnostics.CodeAnalysis;

namespace KontackPortal.DomainLogic.Services
{
    [ExcludeFromCodeCoverage]
    public class EnvironmentService
    {
        public readonly string DevRuntime = "DEV";
        public readonly bool IsDev;
        public readonly bool IsLocal;
        public readonly bool IsPrePod;
        public readonly bool IsProd;
        public readonly bool IsTest;
        public readonly string PreProdRuntime = "PREPROD";
        public readonly string ProdRuntime = "PROD";
        public readonly string RuntimeEnv;
        public readonly string TestRuntime = "UAT";

        public EnvironmentService(string runtimeEnv)
        {
            RuntimeEnv = runtimeEnv.ToUpper();
            IsDev = RuntimeEnv == DevRuntime;
            IsTest = RuntimeEnv == TestRuntime;
            IsPrePod = RuntimeEnv == PreProdRuntime;
            IsProd = RuntimeEnv == ProdRuntime;
            IsLocal = !(IsDev | IsTest | IsPrePod | IsPrePod);
        }
    }
}