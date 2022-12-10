import React from 'react';
import Task from '../Models/Task';
import './Calendar.css'

interface CalendarProps {

}

export const Calendar = (props: CalendarProps) => {
    var daysOnPage = 7;
    var task = new Task();
    task.name = 'Some task';

    function renderTask(task: Task) {
        return (<p className="my-border">{task.name}</p>)
    }

    function renderDay(day: number) {
        return (
            <div className="day" style={{ width: `${100 / daysOnPage}%` }}>
                <h3 className="my-border">{day}</h3>
                <>{renderTask(task)}</>
                <>{renderTask(task)}</>
                <>{renderTask(task)}</>
            </div>
        )
    }

    return (
        <div className="content">
            {renderDay(1)}
            {renderDay(2)}
            {renderDay(3)}
            {renderDay(4)}
            {renderDay(5)}
            {renderDay(6)}
            {renderDay(7)}
        </div>
    )
}