using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TestSwiper.Wrappers
{
    public enum Placement
    {
        [Description("auto")] Auto,
        [Description("auto-start")] AutoStart,
        [Description("auto-end")] AutoEnd,
        [Description("top")] Top,
        [Description("top-start")] TopStart,
        [Description("top-end")] TopEnd,
        [Description("bottom")] Bottom,
        [Description("bottom-start")] BottomStart,
        [Description("bottom-end")] BottomEnd,
        [Description("right")] Right,
        [Description("right-start")] RightStart,
        [Description("right-end")] RightEnd,
        [Description("left")] Left,
        [Description("left-start")] LeftStart,
        [Description("left-end")] LeftEnd
    }
    
    public class PopperOptions
    {
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }
        
        [JsonPropertyName("modifiers")]
        public List<object> Modifiers { get; set; }
    }
    public class Popper
    {
        private readonly IJSRuntime jSRuntime;

        public Popper(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task CreatePopperAsync(ElementReference reference, ElementReference popper, object options = null)
        {
            await jSRuntime.InvokeVoidAsync("PopperWrapper.createPopper", reference, popper, options);
        }
    }
    
    
    class EnumDescriptionConverter<T> : JsonConverter<T> where T : IComparable, IFormattable, IConvertible
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var description = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);

            writer.WriteStringValue(description.Description);
        }
    }
}


