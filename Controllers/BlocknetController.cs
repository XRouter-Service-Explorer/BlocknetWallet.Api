using Blocknet.Lib.Services.Coins.Base;
using BlocknetWallet.Api.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlocknetWallet.Api.Controllers
{
    [Route("api/blocknet")]
    public class BlocknetController : ControllerBase
    {
        private readonly ICoinService blocknetService;
        public BlocknetController(ICoinService blocknetService)
        {
            this.blocknetService = blocknetService;
        }

        [HttpGet("[action]")]
        public IActionResult VerifyMessage(string address, string signature, string message)
        {
            return Ok(blocknetService.VerifyMessage(address, signature, message));
        }

        [HttpGet("[action]")]
        public IActionResult GetNetworkInfo()
        {
            var networkInfoResponse = blocknetService.GetNetworkInfo();

            return Ok(new GetNetworkResponseViewModel
            {
                ProtocolVersion = networkInfoResponse.ProtocolVersion,
                Subversion = networkInfoResponse.Subversion,
                Version = networkInfoResponse.Version,
                XBridgeProtocolVersion = networkInfoResponse.XBridgeProtocolVersion,
                XRouterProtocolVersion = networkInfoResponse.XRouterProtocolVersion
            });
        }
    }
}
