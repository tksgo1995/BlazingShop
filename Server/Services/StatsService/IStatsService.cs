﻿using System.Threading.Tasks;

namespace BlazingShop.Server.Services.StatsService
{
	public interface IStatsService
	{
		Task<int> GetVisits();
		Task IncrementVisits();
	}
}
