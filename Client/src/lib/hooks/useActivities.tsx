import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import agent from "../api/agent";
import { useLocation } from "react-router";

export const useActivities = (id?: string) => {
    const queryClient = useQueryClient();
    const location = useLocation();

    const { data: activities, isPending } = useQuery({
        queryKey: ['activities'],
        queryFn: async () => {
            try {
                const response = await agent.get<Activity[]>('activities/GetActivities');
                return response.data;
            } catch (error) {
                console.log(error);
            }
        },
        enabled: !id && location.pathname === '/activities/GetActivities'
      });

    const {data: activity, isLoading: isLoadingActivity} = useQuery({
        queryKey: ['activity', id],
        queryFn: async () => {
            const response = await agent.get<Activity>(`activities/GetActivityDetail/${id}`);
            return response.data;
        },
        enabled: !!id
    });

    const createActivity = useMutation({
        mutationFn: async (activity: Activity) => {
            try {
                const response = await agent.post('activities/CreateActivity', activity);
                return response.data;

            } catch (error) {
                console.log(error);
            }
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['activities']
            });
        }
    });

    const deleteActivity = useMutation({
        mutationFn: async (id: string) => {
            try {
                await agent.delete(`activities/DeleteActivity/${id}`);
            } catch (error) {
                console.log(error);
            }
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['activities']
            });
        }
    });

    const updateActivity = useMutation({
        mutationFn: async (activity: Activity) => {
            try {
                await agent.put('activities/EditActivity', activity);
            } catch (error) {
                console.log(error);
            }
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['activities']
            });
        }
    });

    return {
        activities,
        isPending,
        updateActivity,
        createActivity,
        deleteActivity,
        activity,
        isLoadingActivity
    };
}