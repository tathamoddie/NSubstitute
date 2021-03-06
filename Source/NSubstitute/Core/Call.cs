using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
    public class Call : ICall
    {
        private MethodInfo _methodInfo;
        private object[] _arguments;
        private object _target;
        private readonly IParameterInfo[] _parameterInfos;
        private IList<IArgumentSpecification> _argumentSpecifications;

        public Call(MethodInfo methodInfo, object[] arguments, object target): this(methodInfo, arguments, target, null)
        {}

        public Call(MethodInfo methodInfo, object[] arguments, object target, IParameterInfo[] parameterInfos)
        {
            _methodInfo = methodInfo;
            _arguments = arguments;
            _target = target;
            _parameterInfos = parameterInfos ?? GetParameterInfosFrom(_methodInfo);
            _argumentSpecifications = SubstitutionContext.Current.DequeueAllArgumentSpecifications();
        }

        private IParameterInfo[] GetParameterInfosFrom(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            if (parameters == null) return new IParameterInfo[0];
            return parameters.Select(x => new ParameterInfoWrapper(x)).ToArray();
        }

        public IParameterInfo[] GetParameterInfos()
        {
            return _parameterInfos;
        }

        public IList<IArgumentSpecification> GetArgumentSpecifications()
        {
            return _argumentSpecifications;
        }

        public Type GetReturnType()
        {
            return _methodInfo.ReturnType;
        }

        public MethodInfo GetMethodInfo()
        {
            return _methodInfo;
        }

        public object[] GetArguments()
        {
            return _arguments;
        }

        public object Target()
        {
            return _target;
        }
    }
}
