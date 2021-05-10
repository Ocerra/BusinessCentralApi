using Microsoft.NAV;
using Microsoft.OData;
using System;
using System.Linq;

namespace Ocerra.BusinessCentral.Api
{
    public class BusinessCentralOData : NAV
    {
        private readonly string accessToken;

        public BusinessCentralOData(Uri uri, string accessToken) : base(uri)
        {
            this.accessToken = accessToken;
            
            this.SendingRequest2 += DataServiceContext_SendingRequest2;

            this.EntityParameterSendOption = Microsoft.OData.Client.EntityParameterSendOption.SendOnlySetProperties;

            this.Format.UseJson();

            this.Configurations.RequestPipeline.OnEntryStarting(arg =>
            {
                var resultProps = arg.Entry.Properties.ToList();

                foreach (var prop in resultProps.ToList())
                    //remove empty guid props
                    if (prop.Value?.ToString() == "00000000-0000-0000-0000-000000000000")
                        resultProps.Remove(prop);
                    //remove null Enums props
                    else if (prop.Value is ODataEnumValue && ((ODataEnumValue)prop.Value).Value == null)
                        resultProps.Remove(prop);
                    //remove null props
                    else if (prop.Value == null)
                        resultProps.Remove(prop);

                arg.Entry.Properties = resultProps;
            });
        }

        private void DataServiceContext_SendingRequest2(object sender, Microsoft.OData.Client.SendingRequest2EventArgs e)
        {
            e.RequestMessage.SetHeader("Authorization", "Bearer " + accessToken);
        }
    }
}
