using System;

namespace Evernote.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(ProfileMappings)
            };
        }
    }
}
