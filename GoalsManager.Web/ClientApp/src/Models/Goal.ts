import GoalStep from './GoalStep';

export default class Goal {
	deadline: Date;
	steps: Array<GoalStep>;
	id: number;
	userId: string;
	name: string;
	description: string;
	creationDate: Date;
	isComplete: boolean;
}