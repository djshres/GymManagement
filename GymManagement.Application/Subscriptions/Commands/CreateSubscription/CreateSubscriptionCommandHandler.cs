using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
         var subscription = new Subscription(
            subscriptionType: request.SubscriptionType,
            adminId: request.AdminId);


        await _subscriptionRepository.AddSubscriptionAsync(subscription);
        await _unitOfWork.CommitChangesAsync();
        return subscription;
    }
}
