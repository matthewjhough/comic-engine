import React from "react";
import { Table, Badge } from "reactstrap";
import styles from "./AbstractTable.module.scss";

export function AbstractTable({ headers, body, deleteBadge, badgeHandler }) {
    return (
        <Table bordered hover responsive>
            <thead>
            <tr>
                <th className={styles.stickyHeader}>#</th>
                {headers.map(header => (<th className={styles.stickyHeader} key={header}>{header}</th>))}
            </tr>
            </thead>
            <tbody> 
            {body.map(((rowValues, index) => (
                <tr key={index}>
                    <th scope="row">
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