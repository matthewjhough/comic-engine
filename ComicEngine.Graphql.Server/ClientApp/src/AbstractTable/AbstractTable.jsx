import React from "react";
import { Table, Badge } from "reactstrap";

export function AbstractTable({ headers, body, deleteBadge, badgeHandler }) {
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
                        {(index + 1)}
                        {deleteBadge && (
                            <Badge
                                style={{ cursor: "pointer" }}
                                onClick={() => badgeHandler && badgeHandler(rowValues, index)}
                                color="danger">Delete</Badge>
                        )}
                    </th>
                    {rowValues.map((value, valueIndex) => (
                        <td key={`${index}-${value}-${valueIndex}`}>{value}</td>
                    ))}
                </tr>)))}
            </tbody>
        </Table>
    );
}