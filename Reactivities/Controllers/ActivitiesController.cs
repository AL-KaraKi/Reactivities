using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Application.Activities.Queries;
using Application.Activities.Commands;
using Application.Activities.DTOs;

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
            return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
        }

        [HttpPost("CreateActivity")]
        public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }, cancellationToken));
        }

        [HttpPut("EditActivity")]
        public async Task<ActionResult> EditActivity(EditActivityDto activity, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDto = activity }, cancellationToken));
        }

        [HttpDelete("DeleteActivity/{id}")]
        public async Task<ActionResult> DeleteActivity(string id, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }, cancellationToken));
        }
    }
}
