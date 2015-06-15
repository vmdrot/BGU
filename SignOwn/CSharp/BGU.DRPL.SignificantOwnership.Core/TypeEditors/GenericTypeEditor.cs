using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public abstract class GenericTypeEditor<T> : UITypeEditor  
    {
        protected abstract ITypeEditorFormFactoryBase TypeEditorFormFactory { get;}
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            string formCaption = string.Empty;
            if(provider is ITypeDescriptorContext)
                formCaption = BGU.DRPL.SignificantOwnership.Utility.Tools.GetPropDescription(((ITypeDescriptorContext)provider).PropertyDescriptor);
            if (string.IsNullOrEmpty(formCaption) && provider is ITypeDescriptorContext)
                formCaption = BGU.DRPL.SignificantOwnership.Utility.Tools.GetPropDisplayName(((ITypeDescriptorContext)provider).PropertyDescriptor);
            if (string.IsNullOrEmpty(formCaption) && value != null)
                formCaption = BGU.DRPL.SignificantOwnership.Utility.Tools.GetObjectClassDescription(value);
            else if (string.IsNullOrEmpty(formCaption) && value == null)
                formCaption = BGU.DRPL.SignificantOwnership.Utility.Tools.GetTypeClassDescription(typeof(T));
            //if (context.Instance != null && context.Instance is IQuestionnaire)
            //    TypeEditorsDispatcher.LastQuestionnaire = (IQuestionnaire)context.Instance;
            System.Windows.Forms.Form frm = TypeEditorFormFactory.SpawnInstance();
            if(value != null)
                ((IDataSourcedForm<T>)frm).DataSource = (T)value;
            if (!string.IsNullOrEmpty(formCaption))
                frm.Text = formCaption;
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return value;
            else
                return ((IDataSourcedForm<T>)frm).DataSource;
            
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

    }
}
