import { environment } from "../../environments/environment";


export async function getEventLogsService(filters?: {
  eventTypeId?: string;
  dateFrom?: string;
  dateTo?: string;
}) {
  
  const params = new URLSearchParams();
  if (filters?.eventTypeId) params.append('eventTypeId', filters.eventTypeId);
  if (filters?.dateFrom)    params.append('dateFrom', filters.dateFrom);
  if (filters?.dateTo)      params.append('dateTo', filters.dateTo);

  const url = params.toString()
    ? `${environment.apiUrl}/api/event-logs?${params.toString()}`
    : environment.apiUrl+"/api/event-logs";

  return fetch(url, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}

export async function getEventLogTypesService(){

    const response: any = await fetch(`${environment.apiUrl}/api/eventLogType`, {
        method: "GET",
        headers: { 
            "Content-Type": "application/json" }
    });

    return response;
}

export async function postEventLogService(request:any){

    const response: any = await fetch(`${environment.apiUrl}/api/event-logs/manual`, {
        method: "POST",
        headers: { 
            "Content-Type": "application/json" },
        body: JSON.stringify(request)
    });

    return response;
}