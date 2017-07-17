﻿define(["sitecore", "/-/speak/v1/ExperienceEditor/ExperienceEditor.js"], function (Sitecore, ExperienceEditor) {
  return ExperienceEditor.PipelinesUtil.generateRequestProcessor("ExperienceEditor.SaveDebugRequests.GetProfileName", function (response) {
    response.context.currentContext.value = response.responseValue.value;
  });
});