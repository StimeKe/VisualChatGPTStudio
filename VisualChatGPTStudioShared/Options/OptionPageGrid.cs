﻿using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace JeffPires.VisualChatGPTStudio.Options
{
    /// <summary>
    /// Represents a class that provides a dialog page for displaying general options.
    /// </summary>
    [ComVisible(true)]
    public class OptionPageGridGeneral : DialogPage
    {
        #region General

        [Category("General")]
        [DisplayName("API Key")]
        [Description("Set API Key. For OpenAI API, see \"https://beta.openai.com/account/api-keys\" for more details.")]
        public string ApiKey { get; set; }

        [Category("General")]
        [DisplayName("OpenAI Service")]
        [Description("Select how to connect: OpenAI API or Azure OpenAI.")]
        [DefaultValue(OpenAIService.OpenAI)]
        [TypeConverter(typeof(EnumConverter))]
        public OpenAIService Service { get; set; }

        [Category("General")]
        [DisplayName("Single Response")]
        [Description("If true, the entire response will be displayed at once (less undo history but longer waiting time).")]
        [DefaultValue(false)]
        public bool SingleResponse { get; set; } = false;

        [Category("General")]
        [DisplayName("Base API")]
        [Description("Change the connection to the OpenAI Base API. format(https://api.openai.com)")]
        [DefaultValue("")]
        public string BaseAPI { get; set; } = string.Empty;

        [Category("General")]
        [DisplayName("Proxy")]
        [Description("Connect to OpenAI through a proxy.")]
        [DefaultValue("")]
        public string Proxy { get; set; } = string.Empty;

        #endregion General

        #region Model Parameters

        [Category("Model Parameters")]
        [DisplayName("Model Language")]
        [Description("See \"https://platform.openai.com/docs/models/overview\" for more details.")]
        [DefaultValue(ModelLanguageEnum.TextDavinci003)]
        [TypeConverter(typeof(EnumConverter))]
        public ModelLanguageEnum Model { get; set; } = ModelLanguageEnum.TextDavinci003;

        [Category("Model Parameters")]
        [DisplayName("Max Tokens")]
        [Description("See \"https://help.openai.com/en/articles/4936856-what-are-tokens-and-how-to-count-them\" for more details.")]
        [DefaultValue(2048)]
        public int MaxTokens { get; set; } = 2048;

        [Category("Model Parameters")]
        [DisplayName("Temperature")]
        [Description("What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 for ones with a well-defined answer.")]
        [DefaultValue(0)]
        [TypeConverter(typeof(DoubleConverter))]
        public double Temperature { get; set; } = 0;

        [Category("Model Parameters")]
        [DisplayName("Presence Penalty")]
        [Description("The scale of the penalty applied if a token is already present at all. Should generally be between 0 and 1, although negative numbers are allowed to encourage token reuse.")]
        [DefaultValue(0)]
        [TypeConverter(typeof(DoubleConverter))]
        public double PresencePenalty { get; set; } = 0;

        [Category("Model Parameters")]
        [DisplayName("Frequency Penalty")]
        [Description("The scale of the penalty for how often a token is used. Should generally be between 0 and 1, although negative numbers are allowed to encourage token reuse.")]
        [DefaultValue(0)]
        [TypeConverter(typeof(DoubleConverter))]
        public double FrequencyPenalty { get; set; } = 0;

        [Category("Model Parameters")]
        [DisplayName("top p")]
        [Description("An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.")]
        [DefaultValue(0)]
        [TypeConverter(typeof(DoubleConverter))]
        public double TopP { get; set; } = 0;

        [Category("Model Parameters")]
        [DisplayName("Stop Sequences")]
        [Description("Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence. Separate different stop strings by a comma e.g. '},;,stop'")]
        [DefaultValue("")]
        public string StopSequences { get; set; } = string.Empty;

        #endregion Model Parameters       

        #region Turbo Chat Window

        [Category("Turbo Chat Window")]
        [DisplayName("Turbo Chat Behavior")]
        [Description("Set the behavior of the assistant.")]
        [DefaultValue("You are a programmer assistant called Visual chatGPT Studio, and your role is help developers and resolve programmer problems.")]
        public string TurboChatBehavior { get; set; } = "You are a programmer assistant called Visual chatGPT Studio, and your role is help developers and resolve programmer problems.";

        [Category("Turbo Chat Window")]
        [DisplayName("Turbo Chat Model Language")]
        [Description("Set the Turbo Chat Model Language. See \"https://platform.openai.com/docs/guides/chat\" for more details.")]
        [DefaultValue(TurboChatModelLanguageEnum.GPT_3_5_Turbo)]
        [TypeConverter(typeof(EnumConverter))]
        public TurboChatModelLanguageEnum TurboChatModelLanguage { get; set; } = TurboChatModelLanguageEnum.GPT_3_5_Turbo;

        #endregion Turbo Chat Window

        #region Azure

        [Category("Azure")]
        [DisplayName("Azure OpenAI Resource Name")]
        [Description("Set Azure OpenAI resource name.")]
        [DefaultValue("")]
        public string AzureResourceName { get; set; } = string.Empty;

        [Category("Azure")]
        [DisplayName("Azure Deployment ID")]
        [Description("Set Azure OpenAI deployment id.")]
        [DefaultValue("")]
        public string AzureDeploymentId { get; set; } = string.Empty;

        [Category("Azure")]
        [DisplayName("Azure Turbo Chat Deployment ID")]
        [Description("Set Azure OpenAI deployment id specific for the Turbo Chat window. This deployment has to be parameterized with the GPT-3.5-Turbo or GPT-4 model.")]
        [DefaultValue("")]
        public string AzureTurboChatDeploymentId { get; set; } = string.Empty;

        [Category("Azure")]
        [DisplayName("Azure Turbo Chat API Version")]
        [Description("Set the Azure OpenAI API version for the Turbo Chat window used on the deployment with the GPT-3.5-Turbo or GPT-4 model.")]
        [DefaultValue("")]
        public string AzureTurboChatApiVersion { get; set; } = string.Empty;

        #endregion Azure

        #region OpenAI

        [Category("OpenAI")]
        [DisplayName("OpenAI Organization")]
        [Description("Set the OpenAI Organization.")]
        public string OpenAIOrganization { get; set; }

        #endregion OpenAI
    }

    /// <summary>
    /// Enum containing the different types of model languages.
    /// </summary>
    public enum ModelLanguageEnum
    {
        TextDavinci003,
        TextCurie001,
        TextBabbage001,
        TextAda001
    }

    /// <summary>
    /// Enum to represent the language model used by TurboChat. 
    /// </summary>
    public enum TurboChatModelLanguageEnum
    {
        GPT_3_5_Turbo,
        GPT_4
    }

    /// <summary>
    /// Enum to represent the different OpenAI services available.
    /// </summary>
    public enum OpenAIService
    {
        OpenAI,
        AzureOpenAI
    }
}
