namespace MJRefresh
{
	public enum MJRefreshState : uint
	{
		Pulling = 1,
		Normal = 2,
		Refreshing = 3,
		WillRefreshing = 4
	}

	public enum MJRefreshViewType
	{
		Header = -1,
		Footer = 1
	}
}
