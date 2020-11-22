import { defaultTo, get } from "lodash";

export function getOrDefault(data, property, defaultValue) {
    return defaultTo(get(data, property), defaultValue);
}