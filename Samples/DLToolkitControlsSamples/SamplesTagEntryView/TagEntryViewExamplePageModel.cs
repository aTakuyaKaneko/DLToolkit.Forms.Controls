using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamvvm;

namespace DLToolkitControlsSamples
{
	public class TagEntryViewExamplePageModel : BasePageModel
	{
		public TagEntryViewExamplePageModel()
		{
			RemoveTagCommand = new BaseCommand<TagItem>((arg) => RemoveTag(arg));
			TagValidator = new DelegateTagValidator(ValidateAndReturn);
		}

		public void ReloadTags()
		{
			var tags = new ObservableCollection<TagItem>(){
				new TagItem() { Name = "#TagExample" },
				new TagItem() { Name = "#Xamarin" },
				new TagItem() { Name = "#DanielLuberda" },
				new TagItem() { Name = "#Test" },
				new TagItem() { Name = "#XamarinForms" },
				new TagItem() { Name = "#TagEntryView" },
				new TagItem() { Name = "#TapMe!" },
				new TagItem() { Name = "#itsworking!" },
			};

			Items = tags;
		}

		public void RemoveTag(TagItem tagItem)
		{
			if (tagItem == null)
				return;

			Items.Remove(tagItem);
		}

		TagItem ValidateAndReturn(string tag)
		{
			if (string.IsNullOrWhiteSpace(tag))
				return null;

			var tagString = tag.StartsWith("#") ? tag : "#" + tag;

			if (Items.Any(v => v.Name.Equals(tagString, StringComparison.OrdinalIgnoreCase)))
				return null;

			return new TagItem()
			{
				Name = tagString.ToLower()
			};
		}

		public IBaseCommand RemoveTagCommand
		{
			get { return GetField<IBaseCommand>(); }
			set { SetField(value); }
		}

		public ObservableCollection<TagItem> Items
		{
			get { return GetField<ObservableCollection<TagItem>>(); }
			set { SetField(value); }
		}

		public DelegateTagValidator TagValidator { get; }

		public class TagItem : BaseModel
		{
			string name;
			public string Name
			{
				get { return name; }
				set { SetField(ref name, value); }
			}
		}
	}

	public class DelegateTagValidator : DLToolkit.Forms.Controls.ITagValidator
	{
		Func<string, object> _validate;

		public DelegateTagValidator(Func<string, object> validate)
		{
			_validate = validate;
		}

		public object ValidateAndCreate(string tag)
		{
			return _validate(tag);
		}
	}
}
