using System.Collections.Generic;
using GitCommands;
using GitUIPluginInterfaces;

namespace ResourceManager
{
    public abstract class GitPluginBase : IGitPlugin, ITranslate
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        //Store settings to use later
        public ISettingsSource Settings { get; set; }

        public virtual IEnumerable<ISetting> GetSettings()
        {
            return new List<ISetting>();
        }

        public virtual void Register(IGitUICommands gitUiCommands)
        {
        }

        public virtual void Unregister(IGitUICommands gitUiCommands)
        {
        }

        public abstract bool Execute(GitUIBaseEventArgs gitUiCommands);

        protected void Translate()
        {
            Translator.Translate(this, AppSettings.CurrentTranslation);
        }

        public virtual void AddTranslationItems(ITranslation translation)
        {
            string name = GetType().Name;
            TranslationUtils.AddTranslationItem(name, this, "Description", translation);
            TranslationUtils.AddTranslationItemsFromFields(name, this, translation);
        }

        public virtual void TranslateItems(ITranslation translation)
        {
            string name = GetType().Name;
            TranslationUtils.TranslateProperty(name, this, "Description", translation);
            TranslationUtils.TranslateItemsFromFields(name, this, translation);
        }
    }
}
