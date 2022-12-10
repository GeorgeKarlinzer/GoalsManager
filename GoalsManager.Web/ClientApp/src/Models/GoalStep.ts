import Goal from './Goal';

export default class GoalStep {
	id: number;
	goalId: number;
	completeDate: Date;
	goal: Goal;
}