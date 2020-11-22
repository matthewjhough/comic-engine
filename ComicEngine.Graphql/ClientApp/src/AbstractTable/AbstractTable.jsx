import React from "react";
import { Table } from "reactstrap";

export function AbstractTable({ headers, body }) {
    return (
        <Table bordered hover dark responsive>
            <thead>
            <tr>
                <th>#</th>
                {headers.map(header => (<th key={header}>{header}</th>))}
            </tr>
            </thead>
            <tbody> 
            {body.map(((rowValues, index) => (
                <tr key={index}>
                    <th scope="row">
                        {index + 1}
                    </th>
                    {rowValues.map((value, valueIndex) => (
                        <td key={`${index}-${value}-${valueIndex}`}>{value}</td>
                    ))}
                </tr>)))}
            </tbody>
        </Table>
    );
}