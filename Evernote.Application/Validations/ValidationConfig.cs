using System;

namespace Evernote.Application.Validations
{
    public class ValidationConfig
    {
        public static Type[] RegisterValidations()
        {
            return new Type[]
            {
                typeof(NoteValidator)
            };
        }
    }
}
