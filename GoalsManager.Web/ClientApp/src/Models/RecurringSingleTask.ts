import RecurringTask from './RecurringTask';

export default class RecurringSingleTask {
	id: number;
	taskId: number;
	isComplete: boolean;
	deadLine: Date;
	task: RecurringTask;
}