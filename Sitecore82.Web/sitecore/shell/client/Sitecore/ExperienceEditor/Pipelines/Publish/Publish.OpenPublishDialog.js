define(["sitecore", "/-/speak/v1/ExperienceEditor/ExperienceEditor.js"], function (Sitecore, ExperienceEditor) {
    return {
        priority: 2,
        execute: function (context) {
            // TODO: Check modified flag
            var dialogPath = "/sitecore/shell/Applications/Publish.aspx?id=" + context.currentContext.itemId;
            var dialogFeatures = "dialogHeight: 600px;dialogWidth: 500px;";
            ExperienceEditor.Dialogs.showModalDialog(dialogPath, '', dialogFeatures);
        }
    };
});