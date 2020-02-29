import { connect } from 'react-redux';
import { ComicResults } from './ComicResults';

const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

const mapDispatchToProps = dispatch => ({});

export const ComicResultsContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ComicResults);
