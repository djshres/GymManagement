using System;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionRepository : ISubscriptionsRepository
{
    private readonly static List<Subscription> _subscription = new();
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscription.Add(subscription);
        return Task.CompletedTask;
    }

    public Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        var subscription = _subscription.FirstOrDefault(x => x.Id == subscriptionId);
        return Task.FromResult(subscription);
    }
}
