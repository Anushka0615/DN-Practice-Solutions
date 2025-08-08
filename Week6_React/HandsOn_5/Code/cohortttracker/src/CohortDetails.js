import React from 'react';
import styles from './CohortDetails.module.css';

function CohortDetails({ cohort }) {
  if (!cohort) return null;

  const status = cohort.currentStatus || '';
  const isOngoing = status.toLowerCase() === 'ongoing';

  const headingStyle = {
    color: isOngoing ? 'green' : 'blue',
  };

  return (
    <div className={styles.box}>
      <h3 style={headingStyle}>{cohort.cohortCode}</h3>
      <dl>
        <dt>Start Date:</dt>
        <dd>{cohort.startDate}</dd>
        <dt>Technology:</dt>
        <dd>{cohort.technology}</dd>
        <dt>Trainer:</dt>
        <dd>{cohort.trainerName}</dd>
        <dt>Coach:</dt>
        <dd>{cohort.coachName}</dd>
        <dt>Status:</dt>
        <dd>{cohort.currentStatus}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;
