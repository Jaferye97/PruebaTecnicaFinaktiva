export interface EventLog {
  id: string;
  eventDate: Date;
  description: string;
  eventType: string;
  createdAt: Date;
  referenceId?: string;
  referenceEntity?: string;
  exceptionMessage?: string;
}
