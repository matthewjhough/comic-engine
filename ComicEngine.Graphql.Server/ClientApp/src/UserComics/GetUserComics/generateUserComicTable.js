import styles from "./UserComicTable.module.scss";
import React from "react";

const id_field = "id";
const description_field = "description";
const thumbnail_field = "thumbnail";
const persisted_comic_id = "persistedComicId";
const storage_id = "storageId";

const keyNotEqualToConstants = (key) =>
    (key !== id_field) && 
    (key !== description_field) &&
    (key !== thumbnail_field) &&
    (key !== persisted_comic_id)&&
    (key !== storage_id);

/**
 * Takes the comic result objects, and creates an array in the desired order.
 * Id is specified as first, and description is specified as end of array.
 * 
 * @param data
 * @returns {string[]}
 */
export function createUserComicHeaders(data) {
    if (data.length < 1) {
        return [];
    } 
    
    return [id_field, thumbnail_field]
        .concat(Object
        .keys(data.comic)
        .filter(keyNotEqualToConstants)
        .concat([description_field]));
}

export function handleImageValue(url, row, rowIndex) {
    return (
        <img key={`img-row-${rowIndex}`} 
             style={{ maxWidth: "150px" }}
             className={styles.comicResultImage}
             src={url}
             alt={`${row.comic.title} thumbnail`}
        />
    );
}

export function createUserComicBody(headers, data) {
    if (!data) {
        return [];
    }
    
    return data.map((row, rowIndex) => 
        headers.map(heading => {
            if (heading === thumbnail_field) {
                return handleImageValue(row.comic[heading], row, rowIndex);
            }
            
            return row.comic[heading];
        }));
}