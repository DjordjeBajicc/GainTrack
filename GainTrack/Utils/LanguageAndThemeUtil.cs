using GainTrack.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GainTrack.Utils
{
    class LanguageAndThemeUtil
    {
        public static ObservableCollection<LanguageTheme> loadLanguagesOrThemes(String Folder)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(executablePath, @"..\..\.."));
            
            string themesFolderPath = Path.Combine(projectPath, Folder);
            
            var files = Directory.GetFiles(themesFolderPath);
            var list = new ObservableCollection<LanguageTheme>();
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                LanguageTheme theme = new LanguageTheme { Name = name, Path = file };
                list.Add(theme);
            }
            return list;
        }

        public static void ChangeLanguage(string language)
        {
            ObservableCollection<LanguageTheme> loadedLanguages = loadLanguagesOrThemes("Resources");
            foreach (LanguageTheme lang in loadedLanguages) {
                if (lang.Name.Equals(language)){
                    ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(lang.Path) };
                    foreach (DictionaryEntry entry in resourceDictionary)
                        App.Current.Resources[entry.Key] = entry.Value;
                }
            }
        }

        public static void ChangeTheme(string theme)
        {
            ObservableCollection<LanguageTheme> loadedLanguages = loadLanguagesOrThemes("Themes");
            foreach (LanguageTheme th in loadedLanguages)
            {
                if (th.Name.Equals(theme))
                {
                    ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(th.Path) };
                    foreach (DictionaryEntry entry in resourceDictionary)
                        App.Current.Resources[entry.Key] = entry.Value;
                }
            }
        }

        public static void ChangeLanguage(LanguageTheme language)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(language.Path) };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }

        public static void ChangeTheme(LanguageTheme theme)
        {
            
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(theme.Path) };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }
    }
}
