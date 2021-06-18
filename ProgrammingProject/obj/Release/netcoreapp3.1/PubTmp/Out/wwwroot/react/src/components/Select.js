import React from "react";

export default function Select({ sign }) {
    function getOptions() {
        const date = new Date()
        const dateArray = [(date.toLocaleString('default', { month: 'long', year: 'numeric' }))];
        if (sign < 0) {
            for (let index = -1; index > -12; index--) {
                date.setMonth(date.getMonth() - 1);
                dateArray.push(date.toLocaleString('default', { month: 'long', year: 'numeric' }))
            }
            return dateArray.map((e, index) => {
                return (<option value={0-index}>{e}</option>)
            });
        }
        else {
            for (let index = 1; index < 3; index++) {
                date.setMonth(date.getMonth() + 1);
                dateArray.push(date.toLocaleString('default', { month: 'long', year: 'numeric' }))
            }
            return dateArray.map((e, index) => {
                return (<option value={index}>{e}</option>)
            });
        }
    }
    if (sign < 0) {
        return (
            <select id="min">
                {getOptions()}
            </select>
        );
    }
    else {
        return (
            <select id="max">
                {getOptions()}
            </select>
        );
    }
}


