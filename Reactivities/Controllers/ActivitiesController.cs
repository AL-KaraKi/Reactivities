using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace Reactivities.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet("GetActivities")]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetActivityList.Query(), cancellationToken);
        }

        [HttpGet("GetActivityDetail/{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query { Id = id });
        }

        [HttpPost("CreateActivity")]
        public async Task<ActionResult<string>> CreateActivity(Activity activity, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new CreateActivity.Command { Activity = activity }, cancellationToken);
        }

        [HttpPut("EditActivity")]
        public async Task<ActionResult> EditActivity(Activity activity, CancellationToken cancellationToken)
        {
            await Mediator.Send(new EditActivity.Command { Activity = activity }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("DeleteActivity/{id}")]
        public async Task<ActionResult> DeleteActivity(string id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
