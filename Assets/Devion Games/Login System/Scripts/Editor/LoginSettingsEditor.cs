using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DevionGames.LoginSystem.Configuration
{
    [System.Serializable]
    public class LoginSettingsEditor : ScriptableObjectCollectionEditor<Settings>
    {
        [SerializeField]
        protected List<string> searchFilters;
        [SerializeField]
        protected string searchFilter = "All";


        public override string ToolbarName
        {
            get
            {
                return "Settings";
            }
        }

        protected override bool AddButton
        {
            get
            {
                return false;
            }
        }

        protected override bool RemoveButton
        {
            get
            {
                return false;
            }
        }

        public LoginSettingsEditor(UnityEngine.Object target, List<Settings> items, List<string> searchFilters) : base(target, items)
        {
            this.target = target;
            this.items = items;
            this.searchFilters = searchFilters;
            this.searchFilters.Insert(0, "All");
            this.searchString = "All";

            Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => typeof(Settings).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToArray();

            foreach (Type type in types)
            {
                if (Items.Where(x => x.GetType() == type).FirstOrDefault() == null)
                {
                    CreateItem(type);
                }
            }
        }

        protected override void DoSearchGUI()
        {
            string[] searchResult = UnityEditorUtility.SearchField(searchString, searchFilter, searchFilters, GUILayout.Width(sidebarRect.width - 20));
            searchFilter = searchResult[0];
            searchString = searchResult[1];
        }

        protected override bool MatchesSearch(Settings item, string search)
        {
            return true;
        }

        protected override string ButtonLabel(int index, Settings item)
        {
            return "  " + GetSidebarLabel(item);
        }
    }
}