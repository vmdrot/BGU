using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;

namespace BGU.DRPL.SignificantOwnership.Core.Checks
{
    public interface IQuestionnaireChecker
    {
        IQuestionnaire Questionnaire { get; set; }
        decimal UnkownOwnersTolerancePct { get; set; }
        Dictionary<BGU.DRPL.SignificantOwnership.Core.Spares.EntityType, decimal> AggregateBankOwnersByEntityType();
        bool CheckOwnershipCompleteness();
        bool CheckMissingPersons();
        bool CheckMissingPersonsLinks();
        //List<OwnershipStructure> ListUltimateBeneficiaries();
        //List<OwnershipStructure> ListUltimateBeneficiaries(GenericPersonID forEntity);
        string BuildOwnershipGraph();
        string IndentString { get; set; }
    }
}
