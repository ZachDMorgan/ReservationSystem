import React, { useState, useEffect } from "react";
import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    Legend,
    ResponsiveContainer
} from "recharts";
import Select from './components/Select'

export default function App() {
    const [data, setData] = useState(null);
    const [limit, setLimit] = useState([]);
    useEffect(() => {
        if (limit.length === 0) { }
        else if (limit === "all") {
            const url = "/api/sittings/getGraphData";
            fetch(url)
                .then(response => { return response.json() })
                .then(d => { setData(d) });
        }
        else {
            const url = `/api/sittings/getGraphData/${limit[0]}/${limit[1]}`;
            fetch(url)
                .then(response => { return response.json() })
                .then(d => { setData(d) });
        }
    }, [limit]);

    function CustomTooltip({ payload, label, active }) {
        if (active) {
            return (
                <div className="custom-tooltip" style={{ backgroundColor: 'white', padding: 5, border: '1px black solid' }}>
                    <p className="label">{`${label}`}</p>
                    <p className="start">{`Start: ${payload[0].payload.startTime}`}</p>
                    <p className="end">{`End: ${payload[0].payload.endTime}`}</p>
                    <p className="capacity" style={{ color: "#82ca9d" }}>{`Capacity: ${payload[0].payload.capacity}`}</p>
                    <p className="pax" style={{ color: "#8884d8" }}>{`PAX: ${payload[0].payload.pax}`}</p>
                </div>
            );
        }

        return null;
    }

    function getDataRange() {
        let min = document.getElementById("min");
        let minValue = min.options[min.selectedIndex].value
        let max = document.getElementById("max");
        let maxValue = max.options[max.selectedIndex].value
        if (isNaN(minValue)) {
            document.getElementById("min").innerHTML = "Please choose a min date";
        }
        else if (isNaN(maxValue)) {
            document.getElementById("min").innerHTML = "Please choose a max date";
        }
        else {
            setLimit([minValue, maxValue]);
        }
    }

    function getAll() {
        setLimit("all");
    }

    if (data) {

        return (
            <div>
                <div className="m-1">
                    <h2>Please choose a dataset</h2>
                    <div>
                        <div className="get-all">
                            <button className="btn btn-primary m-1" onClick={getAll}>Get All Dates</button>
                        </div>
                        <div className="wrapper">
                            <div className="inputs">
                                <div>
                                    <label>Starting Month</label>
                                    <Select sign={-1} />
                                </div>
                                <div>
                                    <label>Final Month</label>
                                    <Select sign={0} />
                                </div>
                            </div>
                            <div className="output">
                                <button className="btn btn-primary m-1" onClick={getDataRange}>Submit</button>
                            </div>
                        </div>
                    </div>
                    <div id="error"></div>
                </div>

                <ResponsiveContainer width="100%" aspect={2}>
                    <LineChart
                        width={500}
                        height={300}
                        data={data}
                        margin={{
                            top: 5,
                            right: 30,
                            bottom: 5
                        }}
                    >
                        <CartesianGrid strokeDasharray="3 3" />
                        <XAxis dataKey="name" />
                        <YAxis />
                        <Tooltip content={<CustomTooltip />} />
                        <Legend />
                        <Line
                            type="monotone"
                            dataKey="pax"
                            stroke="#8884d8"
                            activeDot={{ r: 8 }}
                        />
                        <Line type="monotone" dataKey="capacity" stroke="#82ca9d" />
                    </LineChart>
                </ResponsiveContainer>
            </div>
        );
    }
    else {

        return (
            <div className="m-1">
                <h2>Please choose a dataset</h2>
                <div>
                    <div>
                        <button className="btn btn-primary m-1" onClick={getAll}>Get All Dates</button>
                    </div>
                    <div className="wrapper">
                    <div className="inputs">
                        <div>
                            <label>Starting Month</label>
                            <Select sign={-1} />
                        </div>
                        <div>
                            <label>Final Month</label>
                            <Select sign={0} />
                        </div>
                    </div>
                        <div className="output">
                            <button className="btn btn-primary m-1" onClick={getDataRange}>Submit</button>
                    </div>
                    </div>
                </div>
                <div id="error"></div>
            </div>

        );
    }
}
