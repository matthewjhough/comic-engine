import React, { useState, useEffect } from 'react';
import {comicEngineUserManager} from "../Authorization/ComicEngineUserManager";
import styles from "./MyProfile.module.scss";

export function MyProfile() {
    const [profile, setProfile] = useState({});

    useEffect(() => {
        comicEngineUserManager.getUser().then(user => {
            console.auth("MyProfile User returned", user);
            setProfile(user.profile);
        });
    }, [comicEngineUserManager.getUser])
    
    console.auth("MyProfile profile: ", profile);
    
    if (!profile.sub) {
        return <div>Loading</div>
    }
    
    return (<div>
        <p className={styles.profileValue}><label className={styles.profileLabel}>Name:</label><span>{profile.name}</span></p>
        <p className={styles.profileValue}><label className={styles.profileLabel}>Website:</label><span>{profile.website}</span></p>
    </div>)
}