import RecurringSingleTask from './RecurringSingleTask';

export default class RecurringTask {
	singleTasks: Array<RecurringSingleTask>;
	id: number;
	userId: string;
	name: string;
	description: string;
	creationDate: Date;
	isComplete: boolean;
}