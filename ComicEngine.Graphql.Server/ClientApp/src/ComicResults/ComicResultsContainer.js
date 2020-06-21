import { connect } from 'react-redux';
import { ComicResults } from './ComicResults';

const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

export const ComicResultsContainer = connect(
  mapStateToProps,
  null
)(ComicResults);
