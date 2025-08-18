export interface EventLog {
  eventDate: Date;
  description: string;
  eventType: string;
  exceptionMessage?: string;
}
