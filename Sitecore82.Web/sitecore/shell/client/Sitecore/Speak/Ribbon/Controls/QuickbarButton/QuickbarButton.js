﻿define(["sitecore"], function(Sitecore) {
    Sitecore.Factories.createBaseComponent({
        name: "QuickbarButton",
        base: "ButtonBase",
        selector: ".sc-quickbar-button",
        attributes: [
            { name: "command", value: "$el.data:sc-command" },
            { name: "isPressed", value: "$el.data:sc-ispressed" }
        ],
        initialize: function() {
            this._super();
            this.model.on("change:isEnabled", this.toggleEnable, this);
            this.model.on("change:isVisible", this.toggleVisible, this);
            this.model.on("change:isPressed", this.togglePressed, this);
        },
        toggleEnable: function() {
            if (!this.model.get("isEnabled")) {
                this.$el.addClass("disabled");
            } else {
                this.$el.removeClass("disabled");
            }
        },
        toggleVisible: function() {
            if (!this.model.get("isVisible")) {
                this.$el.hide();
            } else {
                this.$el.show();
            }
        },
        togglePressed: function() {
            if (this.model.get("isPressed"))
                this.$el.addClass("pressed");
            else {
                this.$el.removeClass("pressed");
            }
        }
    });
});